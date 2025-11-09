import { createFileRoute, notFound } from "@tanstack/react-router";
import axios, { AxiosError, type AxiosResponse } from "axios";

import type { WrittenWorksAuthor } from "../../interfaces/aozora.types";
import { aozoraApi } from "../../utils/environment-variables";

export const Route = createFileRoute("/authors/$authorId")({
  loader: async ({ params: { authorId } }) => {
    try {
      const response = await axios.get<
        string,
        AxiosResponse<WrittenWorksAuthor>
      >(aozoraApi + `authors/${authorId}`);

      return { author: response.data };
    } catch (error: unknown) {
      if (error instanceof AxiosError) {
        if (error.status === 404) throw notFound();

        throw error;
      }
    }
  },
  component: RouteComponent,
});

function RouteComponent() {
  const loader = Route.useLoaderData();
  const author = loader?.author;

  console.log(author);

  return <div>Hello "/authors/$authorId"!</div>;
}
