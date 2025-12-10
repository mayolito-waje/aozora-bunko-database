# AozoraPlus

AozoraPlus is a lightweight REST API gateway built on top of Aozora Bunko (青空文庫). Its goal is to provide an easy-to-use REST API for developers to browse that can allow them to integrate Aozora Bunko database into their projects.

## Screenshots
![Written works search page](./assets/Screenshot%20from%202025-11-20%2019-01-41.png "Written works page")
![Authors search page](./assets/Screenshot%20from%202025-11-20%2019-04-11.png "Authors search page")
![Book overview page](./assets/Screenshot%20from%202025-11-20%2019-06-42.png "Book overview page")
![Author overview page](./assets/Screenshot%20from%202025-11-20%2019-05-35.png "Author overview page")

## Features
- REST API for authors, written works, and publishers
- React frontend (currently for demonstration purpose)
- Designed as a REST API gateway for Aozora Bunko (青空文庫) website dataset
- Has pagination support

## Endpoints
You can test available endpoints through Swagger UI which is hosted at https://localhost:5001/swagger

## Getting started
### Development setup

#### Backend (root folder)
Start the backend and supporting services with Docker:

```
docker compose up -d --build
```

Services started by Docker:
| Service | Address |
|---|---|
| REST API | https://localhost:5001, http://localhost:3001 |
| Postgres (main db) | localhost:5433 |
| Postgres (Hangfire) | localhost:5434 |

#### Frontend (Client)
From the project root:
```
cd Client
```
Start the frontend (pnpm):
```
pnpm dev
```
Optional: enable TanStack Router route watching
```
pnpm watch-routes
```

#### Testing
Critical API endpoints are tested through integration testing. The test cases uses TestContainers to allow database isolation.

Run tests:
```
# from the repository root
dotnet test

# or run the tests project directly
dotnet test AozoraBunkoDatabase.Tests
```

## Feature Roadmap / Checklist
- ✅ Retrieve authors
- ✅ Retrieve written works
- ✅ Retrieve publishers
- ⬜ Retrieve original source of written works
- ⬜ Login function
- ⬜ Reading / read / plan-to-read / review features
- ⬜ Download ebook (generate EPUB) — planned (Aozora provides text/HTML only)

## License
- Intended as a non-commercial, open developer resource. Add or change license as needed.

Contact notes
- This project is provided as-is to facilitate developer access to Aozora Bunko data. Please respect Aozora Bunko terms when using original content.