import * as kanjidate from "kanjidate";

import type { WrittenWorksAuthor } from "../../interfaces/aozora.types";
import { formatAuthorName } from "../../utils/format-author-name";
import AuthorProfilePicture from "./author-profile-picture";
import { isKana } from "../../utils/kana-checker";
import { useWikipediaAuthorSummary } from "../../hooks/use-wikipedia";

interface Props {
  author: WrittenWorksAuthor;
}

function AuthorOverview({ author }: Props) {
  const fullName = formatAuthorName({
    givenName: author.givenName,
    surname: author.surname,
  });

  const { data: wikipediaData } = useWikipediaAuthorSummary(fullName);

  return (
    <>
      <div className="flex flex-col justify-center items-center gap-2.5 w-5/6 mx-auto mt-5 md:flex-row">
        <div className="flex flex-col items-center md:flex-row p-5 gap-5 w-full rounded-2xl">
          <AuthorProfilePicture author={author} />
          <div className="flex flex-col p-2 gap-2 items-center md:items-start">
            <span className="text-4xl font-bold">{fullName}</span>
            <br />
            <span>
              <strong>名：</strong>
              {author.givenName}{" "}
              {!isKana(author.givenName) ? `(${author.givenNameReading})` : ""}
            </span>
            <br />
            <span>
              <strong>姓：</strong>
              {author.surname}{" "}
              {!isKana(author.surname) ? `(${author.surnameReading})` : ""}
            </span>
            <br />
            <span>
              <strong>生年月日：</strong>
              {author.birthDate
                ? `${kanjidate.format(
                    kanjidate.f1,
                    new Date(author.birthDate)
                  )}`
                : "公開されませんでした。"}
            </span>
            <br />
            <span>
              <strong>没年月日：</strong>
              {author.deathDate
                ? `${kanjidate.format(
                    kanjidate.f1,
                    new Date(author.deathDate)
                  )}`
                : "公開されませんでした。"}
            </span>
            <br />
            <span>
              <strong>人物著作権：</strong>
              {author.personalityRights ? "あり" : "なし"}
            </span>
          </div>
        </div>
        {wikipediaData && wikipediaData.status !== 404 && (
          <div className="w-full mx-auto border-blue-600 border-y-2 p-5 md:rounded-xl md:border-x-2">
            <h3 className="font-bold text-lg">作家について</h3>
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
      </div>
    </>
  );
}

export default AuthorOverview;
