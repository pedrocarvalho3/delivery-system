# DeliverySystem.Web

React frontend for the Delivery System project.

## Run locally

```bash
npm install
npm run dev
```

Routes:

- `/` - public landing page
- `/admin/login` - admin login page

The admin login page calls the backend login endpoint and stores the returned token in local storage.

## API URL

The admin login calls the API at `http://localhost:5247` by default.

To override it, create a `.env.local` file:

```bash
VITE_API_BASE_URL=http://localhost:5247
```
