import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
  component: Index,
});

function Index() {
  return (
    <div className="flex flex-col justify-center gap-1.5 items-center h-[60vh]">
      <h3 className="font-bold text-2xl text-blue-600">青空文庫</h3>
      <p className="text-sm text-blue-600">インターネットの電子図書館</p>
    </div>
  );
}
