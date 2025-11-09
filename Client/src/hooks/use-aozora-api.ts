import { useQuery } from "@tanstack/react-query";
import axios, { type AxiosResponse } from "axios";

import { aozoraApi } from "../utils/environment-variables";
import type {
  WrittenWork,
  WrittenWorksAuthor,
} from "../interfaces/aozora.types";

interface GenericQuery {
  query: string;
  page?: number;
  pageSize?: number;
}

export function useFetchWrittenWorks({
  query,
  page = 1,
  pageSize = 15,
}: GenericQuery) {
  return useQuery({
    queryKey: ["fetch-works", query, page, pageSize],
    queryFn: async () => {
      const response = await axios.get<string, AxiosResponse<WrittenWork[]>>(
        aozoraApi +
          `writtenWorks/?s=${encodeURIComponent(
            query
          )}&page=${page}&pageSize=${pageSize}`
      );

      return response.data;
    },
  });
}

export function useFetchAuthors({
  query,
  page = 1,
  pageSize = 15,
}: GenericQuery) {
  return useQuery({
    queryKey: ["fetch-authors", query, page, pageSize],
    queryFn: async () => {
      const response = await axios.get<
        string,
        AxiosResponse<WrittenWorksAuthor[]>
      >(
        aozoraApi +
          `authors/?s=${encodeURIComponent(
            query
          )}&page=${page}&pageSize=${pageSize}`
      );

      return response.data;
    },
  });
}
