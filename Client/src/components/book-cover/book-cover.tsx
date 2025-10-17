interface Props {
  title: string;
  author: string;
}

export default function BookCover({ title, author }: Props) {
  return (
    <div className="relative bg-[url(/aozora-cover.jpg)] bg-cover w-35 h-50 rounded-lg shadow-2xl">
      <div className="flex flex-col gap-2.5 items-center h-fit mt-10">
        <span className="font-bold text-[0.8rem]">{title}</span>
        <span className="text-[0.5rem]">{author}</span>
      </div>
      <img src="/aozora.png" className="h-5 w-5 absolute bottom-2 left-2" />
    </div>
  );
}
