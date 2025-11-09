import { useQuery } from "@tanstack/react-query";
import axios, { type AxiosResponse } from "axios";

import type { WikipediaSummary } from "../interfaces/wikipedia-summary.types";
import { wikipediaSummary } from "../utils/environment-variables";
import { WIKIPEDIA_OVERRIDES } from "../utils/wikipedia-overrides";
import { WIKIPEDIA_IGNORE } from "../utils/wikipedia-ignore";

export function useWikipediaAuthorThumbnail(author: string) {
  if (author in WIKIPEDIA_OVERRIDES) author = WIKIPEDIA_OVERRIDES[author];

  return useQuery<string | null>({
    queryKey: ["fetch-author-thumbnail", author],
    queryFn: async () => {
      try {
        const tryResult = await axios.get<
          string,
          AxiosResponse<WikipediaSummary>
        >(wikipediaSummary + author);

        if (tryResult.data.thumbnail?.source)
          return tryResult.data.thumbnail.source;
        else return null;
      } catch (error: unknown) {
        if (axios.isAxiosError(error) && error.response?.status === 404)
          return null;

        console.error(error);
      }

      return null;
    },
  });
}

export function useWikipediaAuthorSummary(author: string) {
  if (author in WIKIPEDIA_OVERRIDES) author = WIKIPEDIA_OVERRIDES[author];

  return useQuery<WikipediaSummary | null>({
    queryKey: ["fetch-author-summary", author],
    queryFn: async () => {
      try {
        const tryResult = await axios.get<
          string,
          AxiosResponse<WikipediaSummary>
        >(wikipediaSummary + author);

        return tryResult.data;
      } catch (error: unknown) {
        if (axios.isAxiosError(error) && error.response?.status === 404)
          return null;

        console.error(error);
      }

      return null;
    },
  });
}

export function useWikipediaBookSummary(title: string, author?: string) {
  if (author && author in WIKIPEDIA_OVERRIDES)
    author = WIKIPEDIA_OVERRIDES[author];

  return useQuery<WikipediaSummary | null>({
    queryKey: ["fetch-book-summary", title, author],
    queryFn: async () => {
      const wikiSearch = `${title}_(${author})`;

      if (WIKIPEDIA_IGNORE.has(wikiSearch)) return null;

      const titleSearchList =
        wikiSearch in WIKIPEDIA_OVERRIDES
          ? [WIKIPEDIA_OVERRIDES[wikiSearch]]
          : [wikiSearch, `${title}_(小説)`, title];

      for (const t of titleSearchList) {
        try {
          const tryResult = await axios.get<
            string,
            AxiosResponse<WikipediaSummary>
          >(wikipediaSummary + t);

          return tryResult.data;
        } catch (error: unknown) {
          if (axios.isAxiosError(error) && error.response?.status === 404)
            return null;

          console.error(error);
        }
      }

      return null;
    },
  });
}
