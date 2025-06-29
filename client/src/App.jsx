import React, { useState } from "react";
import OrdersList from "./pages/OrderList";
import CreateOrder from "./pages/CreateOrder";
import OrderView from "./pages/OrderView";

export default function App() {
  // activePage: "list", "create", "view"
  const [activePage, setActivePage] = useState("list");
  const [viewOrderId, setViewOrderId] = useState(null);

  function onOrderClick(id) {
    setViewOrderId(id);
    setActivePage("view");
  }

  function goBack() {
    setActivePage("list");
    setViewOrderId(null);
  }

  return (
    <div style={{ padding: 20, fontFamily: "Arial" }}>
      <nav style={{ marginBottom: 20 }}>
        <button
          onClick={() => setActivePage("create")}
          disabled={activePage === "create"}
          style={{ marginRight: 10 }}
        >
          Создать заказ
        </button>
        <button
          onClick={() => {
            setActivePage("list");
            setViewOrderId(null);
          }}
          disabled={activePage === "list"}
        >
          Посмотреть заказы
        </button>
      </nav>

      {activePage === "list" && <OrdersList onOrderClick={onOrderClick} />}
      {activePage === "create" && <CreateOrder onCreated={() => setActivePage("list")} />}
      {activePage === "view" && viewOrderId && <OrderView orderId={viewOrderId} goBack={goBack} />}
    </div>
  );
}
