import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/react-router-devtools";
import SearchQueryProvider from "../context/search-query/search-query-provider";
import Nav from "../components/nav/nav";
import SearchInput from "../components/search-input/search-input";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";

function RootLayout() {
  return (
    <>
      <SearchQueryProvider>
        <Nav />
        <SearchInput />
        <Outlet />
      </SearchQueryProvider>

      <ReactQueryDevtools />
      <TanStackRouterDevtools />
    </>
  );
}

export const Route = createRootRoute({ component: RootLayout });
