import { useWikipediaAuthorThumbnail } from "../../hooks/use-wikipedia";
import type { WrittenWorksAuthor } from "../../interfaces/aozora.types";
import { formatAuthorName } from "../../utils/format-author-name";

interface Props {
  author: WrittenWorksAuthor;
}

function DisplayAuthorThumbnail({ author }: Props) {
  const { data, isPending } = useWikipediaAuthorThumbnail(
    formatAuthorName({ givenName: author.givenName, surname: author.surname })
  );

  if (isPending) {
    return (
      <div className="p-2.5 h-[250px] w-[200px] flex items-center justify-center">
        <span className="loading loading-dots loading-xl bg-blue-600"></span>
      </div>
    );
  }

  return (
    <figure className="p-2.5">
      {data !== null ? (
        <img src={data} className="h-[250px] w-[200px] rounded-xl" />
      ) : (
        <img
          src="/profile-pic.png"
          className="h-[250px] w-[200px] rounded-xl"
        />
      )}
    </figure>
  );
}

export default DisplayAuthorThumbnail;
