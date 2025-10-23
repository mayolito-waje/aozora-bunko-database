import { isKatakana } from "./kana-checker";

export function formatAuthorName({
  givenName,
  surname,
}: {
  givenName: string | undefined;
  surname: string | undefined;
}) {
  const baseAuthorName = `${surname}${givenName}`;

  const authorName = isKatakana(baseAuthorName)
    ? `${givenName}・${surname}`
    : baseAuthorName;

  return authorName;
}
