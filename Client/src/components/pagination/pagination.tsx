interface Props {
  currentPage: number;
  onClickPrevious: () => void;
  onClickNext: () => void;
}

function Pagination({ currentPage, onClickPrevious, onClickNext }: Props) {
  return (
    <div className="join self-center">
      <button className="join-item btn" onClick={onClickPrevious}>
        «
      </button>
      <button className="join-item btn">{currentPage}</button>
      <button className="join-item btn" onClick={onClickNext}>
        »
      </button>
    </div>
  );
}

export default Pagination;
