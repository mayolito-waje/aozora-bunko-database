import { Link } from "@tanstack/react-router";

export default function Nav() {
  return (
    <>
      <div className="bg-blue-600 flex items-center h-15 pl-2 pr-2 sticky top-0 z-50">
        <Link to="/" className="flex items-center gap-1.5">
          <img src="/aozora.png" className="w-10 h-10" />
          <span className="font-bold text-white text-2xl">青空文庫</span>
        </Link>
      </div>
    </>
  );
}
