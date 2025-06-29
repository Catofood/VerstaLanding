import { useNavigate } from "react-router-dom";

export default function Menu() {
  const navigate = useNavigate();

  return (
    <nav style={{ display: "flex", gap: "1rem", padding: "1rem", background: "#f1f1f1" }}>
      <button onClick={() => navigate("/create")}>Создать заказ</button>
      <button onClick={() => navigate("/")}>Посмотреть заказы</button>
    </nav>
  );
}
