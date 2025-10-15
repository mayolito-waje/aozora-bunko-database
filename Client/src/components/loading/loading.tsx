export default function Loading() {
  return (
    <div className="flex flex-col justify-center items-center">
      <span className="text-sm font-semibold text-blue-600">青空文庫</span>
      <br />
      <span className="loading loading-dots loading-xl bg-blue-600"></span>
    </div>
  );
}
