import { useEffect, useState } from "react";

import WrittenWorksList from "../../components/written-works-list/written-works-list";
import { useAozoraApi } from "../../hooks/use-aozora-api";
import type { WrittenWorks } from "../../interfaces/aozora.type";

export default function WrittenWorks() {
  const api = useAozoraApi();
  const [works, setWorks] = useState<WrittenWorks[]>();

  useEffect(() => {
    const retrievedWorks = api.fetchWrittenWorks();
    setWorks(retrievedWorks.data);
  }, [works, api]);

  return (
    <>
      {works !== undefined ? (
        <WrittenWorksList works={works} />
      ) : (
        <div>青空文庫</div>
      )}
    </>
  );
}
