import { useQuery } from "@tanstack/react-query";
import { notFound } from "@tanstack/react-router";
import axios, { type AxiosResponse } from "axios";

import { aozoraApi } from "../utils/environment-variables";
import type { WrittenWork } from "../interfaces/aozora.type";

interface GenericQuery {
  query: string;
  page?: number;
  pageSize?: number;
}

export function useFetchWrittenWorks({
  query,
  page = 1,
  pageSize = 30,
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

export function useFetchWrittenWorkById(id: string) {
  return useQuery({
    queryKey: ["fetch-work-id", id],
    queryFn: async () => {
      const response = await axios.get<string, AxiosResponse<WrittenWork>>(
        aozoraApi + `writtenWorks/${id}`
      );

      if (response.status === 404) throw notFound();

      return response.data;
    },
  });
}
