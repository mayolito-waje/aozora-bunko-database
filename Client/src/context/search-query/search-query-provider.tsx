import { useState } from "react";
import SearchQueryContext from "./search-query-context";

interface Props {
  children: React.ReactNode;
}

export default function SearchQueryProvider({ children }: Props) {
  const [searchQuery, setSearchQuery] = useState<string>("");

  return (
    <SearchQueryContext.Provider value={{ searchQuery, setSearchQuery }}>
      {children}
    </SearchQueryContext.Provider>
  );
}
