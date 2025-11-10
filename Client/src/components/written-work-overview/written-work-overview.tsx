import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import type { WrittenWork } from "../../interfaces/aozora.types";
import { faDownload, faFileCode } from "@fortawesome/free-solid-svg-icons";

import BookCover from "../book-cover/book-cover";
import BookOverviewTabs from "./book-overview-tabs";
import { useWikipediaBookSummary } from "../../hooks/use-wikipedia";
import { formatAuthorName } from "../../utils/format-author-name";

interface Props {
  work: WrittenWork;
}

export default function WrittenWorkOverview({ work }: Props) {
  const authorName = formatAuthorName({
    givenName: work?.author?.givenName,
    surname: work?.author?.surname,
  });

  const { data: wikipediaData } = useWikipediaBookSummary(
    work.title,
    authorName
  );

  return (
    <>
      <div className="flex flex-col justify-center items-start gap-2.5 w-11/12 mx-auto mt-5">
        <div className="bg-blue-600 flex flex-col items-center md:flex-row p-5 gap-5 w-full text-white rounded-2xl">
          <BookCover title={work?.title as string} author={authorName} />
          <div className="flex flex-col p-2 gap-2 items-center md:items-start">
            <span className="text-xl font-bold">{work?.title}</span>
            <span>{authorName}</span>
            <br />
            <div className="flex gap-2 flex-row">
              <a href={work?.textLink}>
                <button className="btn btn-sm cursor-pointer">
                  <FontAwesomeIcon icon={faDownload} />
                  ダウンロード
                </button>
              </a>
              <a href={work?.htmlLink} target="_blank">
                <button className="btn btn-sm cursor-pointer">
                  <FontAwesomeIcon icon={faFileCode} />
                  HTMLで読む
                </button>
              </a>
            </div>
          </div>
        </div>
      </div>
      {wikipediaData && wikipediaData.status !== 404 && (
        <div className="w-11/12 mx-auto mt-5 border-blue-600 border-y-2 py-2">
          <h3 className="font-bold text-lg">作品について</h3>
          <br />
          <div className="mx-5">
            <p>{wikipediaData?.extract}</p>
            <br />
            <a
              href={wikipediaData?.content_urls?.desktop?.page}
              target="_blank"
            >
              <button className="btn btn-outline btn-info cursor-pointer">
                <i className="fa-brands fa-wikipedia-w"></i>
                Wikipedia
              </button>
            </a>
          </div>
        </div>
      )}
      <BookOverviewTabs work={work} />
    </>
  );
}
