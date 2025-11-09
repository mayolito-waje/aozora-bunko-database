export function isKatakana(
  input: string,
  { allowSpaces = true, allowPunctuation = true, convertHalfwidth = true } = {}
) {
  if (!input) return false;

  const str = convertHalfwidth ? input.normalize("NFKC").trim() : input.trim();

  const base = "\\u30A0-\\u30FF\\u30FC\\u30FB";
  const alpha = "A-Za-z";
  const space = allowSpaces ? "\\s" : "";
  const punctuation = allowPunctuation ? "\\p{P}・" : "";
  const pattern = `^[${base}${alpha}${space}${punctuation}]+$`;
  const re = new RegExp(pattern, "u");

  return re.test(str);
}
