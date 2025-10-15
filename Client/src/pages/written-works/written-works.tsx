import WrittenWorksList from "../../components/written-works-list/written-works-list";
import { useAozoraApi } from "../../hooks/use-aozora-api";
import type { WrittenWorks } from "../../interfaces/aozora.type";
import Loading from "../../components/loading/loading";

export default function WrittenWorks() {
  const { fetchWrittenWorks } = useAozoraApi();
  const { data, isPending } = fetchWrittenWorks;

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
