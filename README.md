cd VerstaLanding
docker-compose up -d
dotnet ef database update
cd ../../client
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
npm run dev

http://localhost:8080/swagger/index.html

