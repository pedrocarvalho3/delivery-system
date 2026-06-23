import Button from "../../../components/Button.tsx";
import PublicHeader from "../components/PublicHeader.tsx";

const flowItems = [
  {
    title: "Choose your order",
    description: "Browse fresh meals and pick what fits your moment.",
  },
  {
    title: "Enter your address",
    description: "Tell us where to deliver and confirm your details.",
  },
  {
    title: "Track your delivery",
    description: "Follow the progress until your food reaches your door.",
  },
];

export default function LandingPage() {
  return (
    <main className="public-page">
      <PublicHeader />

      <section className="hero-section">
        <div className="hero-content">
          <p className="eyebrow">Restaurant delivery</p>
          <h1>Cia Oriental</h1>
          <p className="hero-subtitle">
            A simple way to order meals from your favorite restaurant and follow
            every step of the delivery.
          </p>
          <Button type="button">Menu</Button>
        </div>

        <div className="hero-preview" aria-hidden="true">
          <div className="plate">
            <span className="plate-item plate-item-main" />
            <span className="plate-item plate-item-side" />
            <span className="plate-item plate-item-small" />
          </div>
          <div className="order-ticket">
            <span>Order preview</span>
            <strong>Fresh combo</strong>
          </div>
        </div>
      </section>

      <section className="flow-section" aria-labelledby="flow-title">
        <div className="section-heading">
          <p className="eyebrow">How it works</p>
          <h2 id="flow-title">From kitchen to your address</h2>
        </div>

        <div className="flow-grid">
          {flowItems.map((item, index) => (
            <article className="flow-card" key={item.title}>
              <span className="flow-number">{index + 1}</span>
              <h3>{item.title}</h3>
              <p>{item.description}</p>
            </article>
          ))}
        </div>
      </section>
    </main>
  );
}
