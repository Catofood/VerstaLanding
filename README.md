git clone https://github.com/Catofood/VerstaLanding
cd VerstaLanding
docker-compose up -d
dotnet ef database update
cd ../../client
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
npm install
npm run dev

http://localhost:8080/swagger/index.html

