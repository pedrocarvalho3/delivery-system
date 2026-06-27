const accessTokenKey = "accessToken";

type JwtPayload = {
  exp?: number;
};

export function getAccessToken() {
  return localStorage.getItem(accessTokenKey);
}

export function saveAccessToken(token: string) {
  localStorage.setItem(accessTokenKey, token);
}

export function removeAccessToken() {
  localStorage.removeItem(accessTokenKey);
}

export function isAccessTokenValid() {
  const token = getAccessToken();

  if (!token) {
    return false;
  }

  const payload = getJwtPayload(token);

  if (!payload?.exp) {
    return false;
  }

  return payload.exp * 1000 > Date.now();
}

function getJwtPayload(token: string): JwtPayload | null {
  try {
    const [, payload] = token.split(".");

    if (!payload) {
      return null;
    }

    const normalizedPayload = payload.replace(/-/g, "+").replace(/_/g, "/");
    const decodedPayload = atob(normalizedPayload);

    return JSON.parse(decodedPayload) as JwtPayload;
  } catch {
    return null;
  }
}
