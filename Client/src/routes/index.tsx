import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
  component: Index,
});

function Index() {
  return (
    <div className="flex justify-center items-center h-screen">
      <h3>青空文庫</h3>
    </div>
  );
}
