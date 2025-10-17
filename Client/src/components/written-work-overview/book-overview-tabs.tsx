import type { WrittenWork } from "../../interfaces/aozora.type";

interface Props {
  work: WrittenWork;
}

export default function BookOverviewTabs({ work }: Props) {
  return (
    <div className="tabs tabs-border w-11/12 mx-auto mt-2">
      <input
        type="radio"
        name="book-overview"
        className="tab text-blue-600"
        aria-label="作品"
        defaultChecked
      />
      <div className="tab-content border-blue-600 bg-base-100 p-10">
        <b>作品名：</b> {work?.title} <br />
        <br />
        {work?.subtitle ? (
          <>
            <b>副題：</b> {work.subtitle} <br />
            <br />
          </>
        ) : null}
        {work?.originalTitle ? (
          <>
            <b>原題：</b> {work.originalTitle} <br />
            <br />
          </>
        ) : null}
        {work?.releaseInfo ? (
          <>
            <b>初出：</b> {work.releaseInfo} <br />
            <br />
          </>
        ) : null}
        <b>文字使い：</b> {work?.writingStyle} <br />
        <br />
        <b>人物の役割：</b> {work?.writerRole} <br />
        <br />
        <b>作品著作権：</b> {work?.workCopyright ? "あり" : "なし"}
        <br />
      </div>

      <input
        type="radio"
        name="book-overview"
        className="tab text-blue-600"
        aria-label="作家"
      />
      <div className="tab-content border-blue-600 bg-base-100 p-10">
        <b>作家名</b>: {work?.author?.surname} {work?.author?.givenName} <br />
        <br />
        <b>ローマ字：</b> {work?.author?.givenNameRomaji}{" "}
        {work?.author?.surnameRomaji} <br />
        <br />
        <b>生年月日：</b> {work?.author?.birthDate} <br />
        <br />
        <b>没年月日：</b> {work?.author?.deathDate} <br />
        <br />
        <b>人物著作権：</b> {work?.author?.personalityRights ? "あり" : "なし"}
      </div>

      <input
        type="radio"
        name="book-overview"
        className="tab text-blue-600"
        aria-label="底本"
      />
      <div className="tab-content border-blue-600 bg-base-100 p-10">
        {work?.source?.name ? (
          <>
            <b>底本名：</b> {work.source.name} <br />
            <br />
          </>
        ) : null}
        {work?.source?.publisherName ? (
          <>
            <b>出版社名：</b> {work?.source?.publisherName} <br />
            <br />
          </>
        ) : null}
        {work?.source?.publishDateInfo ? (
          <>
            <b>底本出版社発行年：</b> {work.source.publishDateInfo} <br />
            <br />
          </>
        ) : null}
        {work?.source?.originalSourceName ? (
          <>
            <b>底本の親本名：</b> {work.source.originalSourceName} <br />
            <br />
          </>
        ) : null}
        {work?.source?.originalSourcePublisherName ? (
          <>
            <b>底本の親元出版社名：</b>{" "}
            {work.source.originalSourcePublisherName} <br />
            <br />
          </>
        ) : null}
        {work?.source?.originalSourcePublishDateInfo ? (
          <>
            <b>底本の親元出版社発行年：</b>{" "}
            {work.source.originalSourcePublishDateInfo} <br />
            <br />
          </>
        ) : null}
      </div>
    </div>
  );
}
