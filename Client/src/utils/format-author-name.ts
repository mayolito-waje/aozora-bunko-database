import { isKana } from "./kana-checker";

export function formatAuthorName({
  givenName,
  surname,
}: {
  givenName: string | undefined;
  surname: string | undefined;
}) {
  const baseAuthorName = `${surname}${givenName}`;

  const authorName = isKana(baseAuthorName)
    ? `${givenName}・${surname}`
    : baseAuthorName;

  return authorName;
}
