import React, { useState } from "react";
import api from "../api/axios";

const initialState = {
  senderCity: "",
  senderAddress: "",
  receiverCity: "",
  receiverAddress: "",
  packageWeightKg: "",
  packagePickupDate: "",
};

export default function CreateOrder({ onCreated }) {
  const [form, setForm] = useState(initialState);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  function onChange(e) {
    setForm(prev => ({ ...prev, [e.target.name]: e.target.value }));
  }

  function validate() {
    if (
      !form.senderCity.trim() ||
      !form.senderAddress.trim() ||
      !form.receiverCity.trim() ||
      !form.receiverAddress.trim() ||
      !form.packageWeightKg ||
      !form.packagePickupDate
    ) {
      return false;
    }
    if (isNaN(Number(form.packageWeightKg)) || Number(form.packageWeightKg) <= 0) return false;
    return true;
  }

  async function onSubmit(e) {
    e.preventDefault();
    setError(null);

    if (!validate()) {
      setError("Пожалуйста, заполните все поля корректно.");
      return;
    }

    setLoading(true);
    try {
      await api.post("/orders/create", {
        senderCity: form.senderCity,
        senderAddress: form.senderAddress,
        receiverCity: form.receiverCity,
        receiverAddress: form.receiverAddress,
        packageWeightKg: Number(form.packageWeightKg),
        packagePickupDate: new Date(form.packagePickupDate).toISOString(),
      });
      setForm(initialState);
      onCreated();
    } catch {
      setError("Ошибка при создании заказа.");
    } finally {
      setLoading(false);
    }
  }

  return (
    <form onSubmit={onSubmit} style={{ maxWidth: 400 }}>
      <div>
        <label>Город отправителя</label>
        <input name="senderCity" value={form.senderCity} onChange={onChange} required />
      </div>
      <div>
        <label>Адрес отправителя</label>
        <input name="senderAddress" value={form.senderAddress} onChange={onChange} required />
      </div>
      <div>
        <label>Город получателя</label>
        <input name="receiverCity" value={form.receiverCity} onChange={onChange} required />
      </div>
      <div>
        <label>Адрес получателя</label>
        <input name="receiverAddress" value={form.receiverAddress} onChange={onChange} required />
      </div>
      <div>
        <label>Вес груза (кг)</label>
        <input
          name="packageWeightKg"
          value={form.packageWeightKg}
          onChange={onChange}
          type="number"
          step="0.01"
          min="0"
          required
        />
      </div>
      <div>
        <label>Дата забора груза</label>
        <input
          name="packagePickupDate"
          value={form.packagePickupDate}
          onChange={onChange}
          type="date"
          required
        />
      </div>

      {error && <p style={{ color: "red" }}>{error}</p>}
      <button type="submit" disabled={loading}>
        {loading ? "Сохраняем..." : "Создать заказ"}
      </button>
    </form>
  );
}
