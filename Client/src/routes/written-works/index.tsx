import WrittenWorksList from "../../components/written-works-list/written-works-list";
import { useFetchWrittenWorks } from "../../hooks/use-aozora-api";
import Loading from "../../components/loading/loading";
import { createFileRoute } from "@tanstack/react-router";

interface WrittenWorksPageSearch {
  s?: string;
  page?: number;
  pageSize?: number;
}

export const Route = createFileRoute("/written-works/")({
  component: WrittenWorksPage,
  validateSearch: (search: Record<string, unknown>): WrittenWorksPageSearch => {
    return {
      page: Number(search?.page ?? 1),
      pageSize: Number(search?.pageSize ?? 30),
    };
  },
});

function WrittenWorksPage() {
  const { s: search, page, pageSize } = Route.useSearch();

  const { data, isPending } = useFetchWrittenWorks({
    query: search as string,
    page,
    pageSize,
  });

  if (isPending)
    return (
      <div className="flex justify-center items-center h-screen">
        <Loading />
      </div>
    );

  return (
    <>
      {data !== undefined && data.length > 0 ? (
        <WrittenWorksList works={data} />
      ) : (
        <div className="flex justify-center items-center h-screen">
          検索結果は空っぽでした。
        </div>
      )}
    </>
  );
}
