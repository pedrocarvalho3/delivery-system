import { apiClient } from "./apiClient.ts";

type LoginRequest = {
  email: string;
  password: string;
};

export async function login(request: LoginRequest) {
  const response = await apiClient("/users/login", {
    method: "POST",
    authorized: false,
    body: JSON.stringify(request),
  });

  if (!response.ok) {
    throw new Error("Invalid Credentials");
  }

  return response.text();
}
