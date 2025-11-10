import { useWikipediaAuthorThumbnail } from "../../hooks/use-wikipedia";
import type { WrittenWorksAuthor } from "../../interfaces/aozora.types";
import { formatAuthorName } from "../../utils/format-author-name";

interface Props {
  author: WrittenWorksAuthor;
}

function AuthorProfilePicture({ author }: Props) {
  const { data, isPending } = useWikipediaAuthorThumbnail(
    formatAuthorName({ givenName: author.givenName, surname: author.surname })
  );

  if (isPending) {
    return (
      <img
        src="/profile-pic.png"
        className="h-[250px] w-[250px] rounded-full"
      />
    );
  }

  return (
    <figure className="p-2.5">
      {data !== null ? (
        <img src={data} className="h-[250px] w-[250px] rounded-full" />
      ) : (
        <img
          src="/profile-pic.png"
          className="h-[250px] w-[250px] rounded-full"
        />
      )}
    </figure>
  );
}

export default AuthorProfilePicture;
