# VerstaLanding

Приложение для оформления и просмотра заказов. Backend — ASP.NET Core 9, frontend — React + Vite. Используется PostgreSQL и Docker.

## 📦 Быстрый старт

### 1. Клонировать репозиторий

```bash
git clone https://github.com/Catofood/VerstaLanding
cd VerstaLanding
```

### 2. Запустить PostgreSQL в Docker

```bash
docker-compose up -d
```

### 3. Применить миграции базы данных

```powershell
cd src/Versta.Landing.Api
dotnet ef database update
```

### 4. Запустить backend (откроется в новом окне PowerShell)

```powershell
Start-Process dotnet -ArgumentList "run"
```

### 5. Установить зависимости frontend и запустить React (откроется в новом окне)

```powershell
cd ../../client
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
npm install
Start-Process cmd -ArgumentList "/c npm run dev"
```

## 🌐 Интерфейсы

- Swagger: http://localhost:8080/swagger/index.html
- React UI: http://localhost:5173

## 🛠 Используемый стек

- **Backend:** ASP.NET Core 9 + MediatR + CQRS + EF Core + PostgreSQL
- **Frontend:** React + Vite
- **Контейнеризация:** Docker

## 🧾 Структура

```
VerstaLanding/
├── client/              # React-приложение (Vite)
├── src/
│   ├── Api/             # ASP.NET API (Startup project)
│   ├── Application/     # CQRS + бизнес-логика
│   ├── Domain/          # Модели
│   └── Infrastructure/  # EF Core + миграции
└── docker-compose.yml
```

## ⚠️ Требования

- [.NET SDK 9](https://dotnet.microsoft.com/)
- [Node.js](https://nodejs.org/)
- [Docker](https://www.docker.com/)

---

> 💡 Если в PowerShell нет прав на выполнение скриптов — используйте  
> `Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass` только в рамках сессии.
