import { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import axios, { type AxiosResponse } from "axios";

import { aozoraApi } from "../utils/environment-variables";
import type { WrittenWorks } from "../interfaces/aozora.type";
import useSearchQueryContext from "./use-search-query-context";

export function useAozoraApi() {
  const { searchQuery } = useSearchQueryContext();

  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(30);

  const fetchWrittenWorks = useQuery({
    queryKey: ["fetch-works", searchQuery, page, pageSize],
    queryFn: async () => {
      const response = await axios.get<string, AxiosResponse<WrittenWorks[]>>(
        aozoraApi +
          `writtenWorks/?s=${encodeURIComponent(
            searchQuery
          )}&page=${page}&pageSize=${pageSize}`
      );

      return response.data;
    },
    enabled: searchQuery.length > 0,
  });

  return {
    setPage,
    setPageSize,
    fetchWrittenWorks,
  };
}
