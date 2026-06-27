import { FormEvent, useState } from "react";
import Button from "../../../components/Button.tsx";
import { login } from "../../../services/authApi.ts";
import { useNavigate } from "react-router-dom";

export default function AdminLoginForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState("");
  const [successMessage, setSuccessMessage] = useState("");

  const navigate = useNavigate();

  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    setError("");
    setSuccessMessage("");
    setIsSubmitting(true);

    try {
      const token = await login({ email, password });
      localStorage.setItem("accessToken", token);
      setSuccessMessage("Signed in successfully.");
      navigate("/admin/dashboard");
    } catch (error) {
      const message =
        error instanceof Error ? error.message : "Unable to sign in.";
      setError(message);
    } finally {
      setIsSubmitting(false);
    }
  }

  return (
    <form className="admin-login-form" onSubmit={handleSubmit}>
      <div className="admin-form-header">
        <p className="eyebrow">Admin area</p>
        <h1>Sign in</h1>
      </div>

      <label className="form-field">
        <span>Email</span>
        <input
          type="email"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
          placeholder="admin@example.com"
          autoComplete="email"
          disabled={isSubmitting}
          required
        />
      </label>

      <label className="form-field">
        <span>Password</span>
        <input
          type="password"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
          placeholder="Your password"
          autoComplete="current-password"
          disabled={isSubmitting}
          required
        />
      </label>
      {error && <p className="form-message form-message-error">{error}</p>}
      {successMessage && (
        <p className="form-message form-message-success">{successMessage}</p>
      )}

      <Button type="submit" className="admin-submit">
        Sign in
      </Button>
    </form>
  );
}
