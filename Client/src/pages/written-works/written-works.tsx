import WrittenWorksList from "../../components/written-works-list/written-works-list";
import { useFetchWrittenWorks } from "../../hooks/use-aozora-api";
import type { WrittenWorks } from "../../interfaces/aozora.type";
import Loading from "../../components/loading/loading";
import useSearchQueryContext from "../../hooks/use-search-query-context";

export default function WrittenWorks() {
  const { searchQuery } = useSearchQueryContext();
  const { data, isPending } = useFetchWrittenWorks({ query: searchQuery });

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
