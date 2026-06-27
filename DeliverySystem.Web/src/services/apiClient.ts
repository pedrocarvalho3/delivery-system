import { API_BASE_URL } from "../config/api.ts";
import { getAccessToken, removeAccessToken } from "./authToken.ts";

type ApiClientOptions = RequestInit & {
  authorized?: boolean;
};

export async function apiClient(path: string, options: ApiClientOptions = {}) {
  const { authorized = true, headers, ...requestOptions } = options;
  const requestHeaders = new Headers(headers);

  if (!requestHeaders.has("Content-Type") && requestOptions.body) {
    requestHeaders.set("Content-Type", "application/json");
  }

  if (authorized) {
    const token = getAccessToken();

    if (token) {
      requestHeaders.set("Authorization", `Bearer ${token}`);
    }
  }

  const response = await fetch(`${API_BASE_URL}${path}`, {
    ...requestOptions,
    headers: requestHeaders,
  });

  if (response.status === 401) {
    removeAccessToken();
  }

  return response;
}
