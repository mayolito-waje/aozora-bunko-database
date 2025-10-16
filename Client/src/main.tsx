import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { RouterProvider, createRouter } from "@tanstack/react-router";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

import { routeTree } from "./routeTree.gen";
import NotFound from "./components/not-found/not-found";
import Loading from "./components/loading/loading";

const router = createRouter({
  routeTree,
  defaultNotFoundComponent: NotFound,
  defaultPendingComponent: () => {
    return (
      <div className="flex justify-center items-center h-screen">
        <Loading />
      </div>
    );
  },
});
const queryClient = new QueryClient();

declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
}

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <RouterProvider router={router} />
    </QueryClientProvider>
  </StrictMode>
);
