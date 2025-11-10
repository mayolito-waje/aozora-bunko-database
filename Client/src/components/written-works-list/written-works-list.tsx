import { Link } from "@tanstack/react-router";
import type { WrittenWork } from "../../interfaces/aozora.types";
import BookCover from "../book-cover/book-cover";
import { formatAuthorName } from "../../utils/format-author-name";

interface Props {
  works: WrittenWork[];
  showAuthorName?: boolean;
}

export default function WrittenWorksList({
  works,
  showAuthorName = true,
}: Props) {
  return (
    <div
      id="written-works-list"
      className="grid grid-cols-[repeat(auto-fill,_minmax(250px,_1fr))] gap-2"
    >
      {works.map((work) => {
        return (
          <Link
            key={work.id}
            to="/written-works/$writtenWorkId"
            params={{ writtenWorkId: work.id }}
          >
            <div className="card bg-base-100 shadow-sm max-w-[80vw] min-h-full relative cursor-pointer hover:opacity-75">
              <figure className="p-2">
                <BookCover
                  title={work?.title as string}
                  author={`${work?.author?.surname} ${work?.author?.givenName}`}
                />
              </figure>
              <div className="card-body">
                <h2 className="card-title">{work.title}</h2>
                {showAuthorName ? (
                  <p>
                    {formatAuthorName({
                      givenName: work?.author?.givenName,
                      surname: work?.author?.surname,
                    })}
                  </p>
                ) : null}
                <br />
                <div className=" bg-blue-400 p-1.5 text-center size-fit rounded-2xl flex items-center justify-center">
                  <span className="text-[13px] font-bold text-white">
                    {work.writingStyle}
                  </span>
                </div>
              </div>
            </div>
          </Link>
        );
      })}
    </div>
  );
}
