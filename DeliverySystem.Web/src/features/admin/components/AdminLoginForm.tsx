import { FormEvent, useState } from 'react';
import Button from '../../../components/Button.tsx';

export default function AdminLoginForm() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    console.log({ email, password });
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
          required
        />
      </label>

      <Button type="submit" className="admin-submit">
        Sign in
      </Button>
    </form>
  );
}
