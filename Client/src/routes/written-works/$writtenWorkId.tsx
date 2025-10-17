import { createFileRoute, notFound } from "@tanstack/react-router";
import axios, { AxiosError, type AxiosResponse } from "axios";

import { aozoraApi } from "../../utils/environment-variables";
import type { WrittenWork } from "../../interfaces/aozora.type";
import WrittenWorkOverview from "../../components/written-work-overview/written-work-overview";

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
      <WrittenWorkOverview work={work as WrittenWork} />
    </>
  );
}
