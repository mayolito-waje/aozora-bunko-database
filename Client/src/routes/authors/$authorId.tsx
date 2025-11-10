import { createFileRoute, notFound } from "@tanstack/react-router";
import axios, { AxiosError, type AxiosResponse } from "axios";

import type { WrittenWorksAuthor } from "../../interfaces/aozora.types";
import { aozoraApi } from "../../utils/environment-variables";
import AuthorOverview from "../../components/author-overview/author-overview";
import WrittenWorksList from "../../components/written-works-list/written-works-list";
import Pagination from "../../components/pagination/pagination";
import { formatAuthorName } from "../../utils/format-author-name";
import { useFetchAuthorWorks } from "../../hooks/use-aozora-api";
import { useEffect } from "react";

interface AuthorsPageSearch {
  worksPage?: number;
  worksPageSize?: number;
}

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
  validateSearch: (search: Record<string, unknown>): AuthorsPageSearch => {
    return {
      worksPage: Number(search?.worksPage ?? 1),
      worksPageSize: Number(search?.worksPageSize ?? 10),
    };
  },
  component: RouteComponent,
});

function RouteComponent() {
  const fullUrl = window.location.href;

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [fullUrl]);

  const loader = Route.useLoaderData();
  let { worksPage, worksPageSize } = Route.useSearch();
  const author = loader?.author;
  const navigate = Route.useNavigate();

  if (!author) throw notFound();

  if (typeof worksPage === "undefined" || worksPage < 1) worksPage = 1;
  if (typeof worksPageSize === "undefined" || worksPageSize < 1)
    worksPageSize = 1;

  const { data: works } = useFetchAuthorWorks({
    authorId: author.id,
    page: worksPage,
    pageSize: worksPageSize,
  });

  const previous = () => {
    if (worksPage <= 1) return;

    navigate({
      to: "/authors/$authorId",
      params: { authorId: author.id },
      search: {
        worksPage: worksPage - 1,
        worksPageSize,
      },
    });
  };

  const next = () => {
    if (!works || works?.length < worksPageSize) return;

    navigate({
      to: "/authors/$authorId",
      params: { authorId: author.id },
      search: {
        worksPage: worksPage + 1,
        worksPageSize,
      },
    });
  };

  return (
    <>
      <AuthorOverview author={author} />{" "}
      <div className="w-5/6 mx-auto py-5 flex flex-col gap-5">
        <div>
          <strong>
            「
            {formatAuthorName({
              givenName: author.givenName,
              surname: author.surname,
            })}
            」の作品リスト：
          </strong>
        </div>
        <hr className="h-px border-blue-600 border-solid" />

        {works !== undefined && works.length > 0 ? (
          <WrittenWorksList works={works} showAuthorName={false} />
        ) : (
          <div className="flex justify-center items-center h-screen">
            検索結果は空っぽでした。
          </div>
        )}

        <Pagination
          currentPage={worksPage}
          onClickPrevious={previous}
          onClickNext={next}
        />
      </div>
    </>
  );
}
