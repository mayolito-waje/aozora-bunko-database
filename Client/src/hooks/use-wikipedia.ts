import { useQuery } from "@tanstack/react-query";
import type { WikipediaSummary } from "../interfaces/wikipedia-summary.types";
import axios, { type AxiosResponse } from "axios";

import { wikipediaSummary } from "../utils/environment-variables";
import { WIKIPEDIA_OVERRIDES } from "../utils/wikipedia-entries";
import { WIKIPEDIA_IGNORE } from "../utils/wikipedia-ignore";

export function useWikipediaBookSummary(title: string, author?: string) {
  if (author && author in WIKIPEDIA_OVERRIDES)
    author = WIKIPEDIA_OVERRIDES[author];

  return useQuery<WikipediaSummary | null>({
    queryKey: ["fetch-book-summary", title, author],
    queryFn: async () => {
      if (WIKIPEDIA_IGNORE.has(`${title}_(${author})`)) return null;

      for (const t of [`${title}_(${author})`, `${title}_(小説)`, title]) {
        try {
          const tryResult = await axios.get<
            string,
            AxiosResponse<WikipediaSummary>
          >(wikipediaSummary + t);

          return tryResult.data;
        } catch (error: unknown) {
          // ignore 404s and other request errors to avoid console spam for expected misses
          if (axios.isAxiosError(error) && error.response?.status === 404) {
            continue;
          }

          console.error(error);
        }
      }

      return null;
    },
  });
}
