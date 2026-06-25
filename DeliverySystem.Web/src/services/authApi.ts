import { API_BASE_URL } from "../config/api";

type LoginRequest = {
  email: string;
  password: string;
};

export async function login(request: LoginRequest) {
  const response = await fetch(`${API_BASE_URL}/users/login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(request),
  });

  if (!response.ok) {
    throw new Error("Invalid Credentials");
  }

  console.log(response);

  return response.text();
}
