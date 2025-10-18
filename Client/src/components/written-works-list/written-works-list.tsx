import { Link } from "@tanstack/react-router";
import type { WrittenWork } from "../../interfaces/aozora.type";

interface Props {
  works: WrittenWork[];
}

export default function WrittenWorksList({ works }: Props) {
  return (
    <div
      id="written-works-list"
      className="grid grid-cols-[repeat(auto-fit,_minmax(400px,_1fr))] gap-2"
    >
      {works.map((work) => {
        return (
          <div
            key={work.id}
            className="card bg-base-100 shadow-sm max-w-[80vw] relative"
          >
            <div className="card-body">
              <h2 className="card-title">{work.title}</h2>
              <p>
                {work.author.surname}
                {work.author.givenName}
              </p>
              <br />
            </div>
            <div className="card-actions justify-end relative bottom-3 right-3">
              <Link
                to="/written-works/$writtenWorkId"
                params={{ writtenWorkId: work.id }}
              >
                <button className="btn text-white bg-blue-600 hover:opacity-80">
                  作品の詳細
                </button>
              </Link>
            </div>
            <div className="absolute bottom-5 left-5 bg-blue-400 p-1.5 text-center size-fit rounded-2xl flex items-center justify-center">
              <span className="text-[13px] font-bold text-white">
                {work.writingStyle}
              </span>
            </div>
          </div>
        );
      })}
    </div>
  );
}
