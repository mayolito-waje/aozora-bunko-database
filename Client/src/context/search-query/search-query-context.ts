import { createContext } from "react";

interface SearchQueryContextValue {
  searchQuery: string;
  setSearchQuery: React.Dispatch<React.SetStateAction<string>>;
}

const SearchQueryContext = createContext<SearchQueryContextValue | undefined>(
  undefined
);

export default SearchQueryContext;
