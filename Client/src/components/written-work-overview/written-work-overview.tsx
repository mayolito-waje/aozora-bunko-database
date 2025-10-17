import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import type { WrittenWork } from "../../interfaces/aozora.type";
import { faDownload, faFileCode } from "@fortawesome/free-solid-svg-icons";
import BookCover from "../book-cover/book-cover";
import BookOverviewTabs from "./book-overview-tabs";

interface Props {
  work: WrittenWork;
}

export default function WrittenWorkOverview({ work }: Props) {
  return (
    <>
      <div className="flex flex-col justify-center items-start gap-2.5 w-11/12 mx-auto mt-5">
        <div className="bg-blue-600 flex flex-col items-center md:flex-row p-5 gap-5 w-full text-white rounded-2xl">
          <BookCover
            title={work?.title as string}
            author={`${work?.author?.surname} ${work?.author?.givenName}`}
          />
          <div className="flex flex-col p-2 gap-2 items-center md:items-start">
            <span className="text-xl font-bold">{work?.title}</span>
            <span>
              {work?.author?.surname}
              {work?.author?.givenName}
            </span>
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
      <BookOverviewTabs work={work} />
    </>
  );
}
