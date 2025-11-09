import { Link } from "@tanstack/react-router";

import type { WrittenWorksAuthor } from "../../interfaces/aozora.types";
import { formatAuthorName } from "../../utils/format-author-name";
import DisplayAuthorThumbnail from "./display-author-thumbnail";

interface Props {
  authors: WrittenWorksAuthor[];
}

function AuthorsList({ authors }: Props) {
  return (
    <div
      id="written-works-list"
      className="grid grid-cols-[repeat(auto-fill,_minmax(250px,_1fr))] gap-2"
    >
      {authors.map((author) => {
        return (
          <Link
            to="/authors/$authorId"
            key={author.id}
            params={{ authorId: author.id }}
          >
            <div className="card bg-base-100 shadow-sm max-w-[80vw] relative cursor-pointer hover:opacity-75">
              <DisplayAuthorThumbnail author={author} />
              <div className="card-body">
                <h2 className="card-title">
                  {formatAuthorName({
                    givenName: author.givenName,
                    surname: author.surname,
                  })}
                </h2>
                <p>
                  {author.birthDate && author.deathDate ? (
                    `${new Date(author.birthDate).getFullYear()} - ${new Date(
                      author.deathDate
                    ).getFullYear()}`
                  ) : (
                    <br />
                  )}
                </p>
              </div>
            </div>
          </Link>
        );
      })}
    </div>
  );
}

export default AuthorsList;
