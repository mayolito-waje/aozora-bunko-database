import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";

import Nav from "./components/nav/nav";
import SearchInput from "./components/search-input/search-input";
import SearchQueryProvider from "./context/search-query/search-query-provider";

const queryClient = new QueryClient();

function App() {
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <SearchQueryProvider>
          <Nav />
          <SearchInput />
        </SearchQueryProvider>

        <ReactQueryDevtools initialIsOpen={false} />
      </QueryClientProvider>
    </>
  );
}

export default App;
