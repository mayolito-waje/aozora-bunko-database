import { useContext } from "react";

import SearchQueryContext from "../context/search-query/search-query-context";

const useSearchQueryContext = () => {
  const searchQueryContext = useContext(SearchQueryContext);

  if (searchQueryContext === undefined)
    throw new Error("useSearchQueryContext must be inside SearchQueryProvider");

  return searchQueryContext;
};

export default useSearchQueryContext;
