import { createFileRoute, useNavigate } from "@tanstack/react-router";
import { useFetchAuthors } from "../../hooks/use-aozora-api";
import Loading from "../../components/loading/loading";
import AuthorsList from "../../components/authors-list/authors-list";
import Pagination from "../../components/pagination/pagination";

interface AuthorsPageSearch {
  s?: string;
  page?: number;
  pageSize?: number;
}

export const Route = createFileRoute("/authors/")({
  component: RouteComponent,
  validateSearch: (search: Record<string, unknown>): AuthorsPageSearch => {
    return {
      page: Number(search?.page ?? 1),
      pageSize: Number(search?.pageSize ?? 10),
    };
  },
});

function RouteComponent() {
  const { s: search } = Route.useSearch();
  let { page, pageSize } = Route.useSearch();
  const navigate = useNavigate();

  if (typeof page === "undefined" || page < 1) page = 1;
  if (typeof pageSize === "undefined" || pageSize < 1) pageSize = 1;

  const { data, isPending } = useFetchAuthors({
    query: search as string,
    page,
    pageSize,
  });

  const previous = () => {
    if (page <= 1) return;

    navigate({
      to: "/authors",
      search: {
        s: search,
        page: page - 1,
        pageSize,
      },
    });
  };

  const next = () => {
    if (!data || data?.length < pageSize) return;

    navigate({
      to: "/authors",
      search: {
        s: search,
        page: page + 1,
        pageSize,
      },
    });
  };

  if (isPending)
    return (
      <div className="flex justify-center items-center h-screen">
        <Loading />
      </div>
    );

  return (
    <div className="w-5/6 mx-auto py-5 flex flex-col gap-5">
      <div>「{search}」の検索結果：</div>
      <hr className="h-px border-blue-600 border-solid" />

      {data !== undefined && data.length > 0 ? (
        <AuthorsList authors={data} />
      ) : (
        <div className="flex justify-center items-center h-screen">
          検索結果は空っぽでした。
        </div>
      )}

      <Pagination
        currentPage={page}
        onClickPrevious={previous}
        onClickNext={next}
      />
    </div>
  );
}
