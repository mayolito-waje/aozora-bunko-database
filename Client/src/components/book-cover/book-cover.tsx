interface Props {
  title: string;
  author: string;
  height?: number;
  width?: number;
}

export default function BookCover({
  title,
  author,
  height = 200,
  width = 150,
}: Props) {
  return (
    <div
      className="relative bg-[url(/aozora-cover.jpg)] bg-cover rounded-lg shadow-xs text-white"
      style={{ height: `${height}px`, width: `${width}px` }}
    >
      <div className="flex flex-col gap-2.5 items-center h-fit mt-10">
        <span className="font-bold text-[0.8rem] text-center">{title}</span>
        <span className="text-[0.5rem]">{author}</span>
      </div>
      <img src="/aozora.png" className="h-5 w-5 absolute bottom-2 left-2" />
    </div>
  );
}
