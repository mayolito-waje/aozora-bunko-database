import { createFileRoute, notFound } from "@tanstack/react-router";
import axios, { AxiosError, type AxiosResponse } from "axios";

import { aozoraApi } from "../../utils/environment-variables";
import type { WrittenWork } from "../../interfaces/aozora.type";

export const Route = createFileRoute("/written-works/$writtenWorkId")({
  loader: async ({ params: { writtenWorkId } }) => {
    try {
      const response = await axios.get<string, AxiosResponse<WrittenWork>>(
        aozoraApi + `writtenWorks/${writtenWorkId}`
      );

      return { work: response.data };
    } catch (error: unknown) {
      if (error instanceof AxiosError) {
        if (error.status === 404) throw notFound();

        throw error;
      }
    }
  },
  component: WrittenWorkId,
});

function WrittenWorkId() {
  const loader = Route.useLoaderData();
  const work = loader?.work;

  return (
    <>
      <div className="flex flex-col justify-center items-start gap-2.5">
        <span className="text-xl font-bold">{work?.title}</span>
        <span>
          {work?.author?.surname}
          {work?.author?.givenName}
        </span>
      </div>
    </>
  );
}
