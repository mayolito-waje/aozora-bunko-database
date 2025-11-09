import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faMagnifyingGlass,
  faCaretDown,
} from "@fortawesome/free-solid-svg-icons";
import { useNavigate } from "@tanstack/react-router";

import { useState } from "react";
import useSearchQueryContext from "../../hooks/use-search-query-context";

export default function SearchInput() {
  type SearchQueryType = "作品" | "作家";

  const [inputValue, setInputValue] = useState("");
  const [filter, setFilter] = useState<SearchQueryType>("作品");
  const { setSearchQuery } = useSearchQueryContext();
  const navigate = useNavigate();

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setInputValue(event.target.value);
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    setSearchQuery(inputValue);

    if (inputValue.length > 0) {
      switch (filter) {
        case "作品":
          navigate({ to: "/written-works", search: () => ({ s: inputValue }) });
          break;
        case "作家":
          navigate({ to: "/authors", search: () => ({ s: inputValue }) });
          break;
      }
    } else {
      navigate({ to: "/" });
    }
  };

  return (
    <>
      <form
        className="flex items-center gap-1.5 mx-auto mt-3 w-fit"
        onSubmit={handleSubmit}
      >
        <div className="dropdown">
          <div
            tabIndex={0}
            role="button"
            className="btn m-1 bg-blue-600 text-white"
          >
            {filter}
            <FontAwesomeIcon icon={faCaretDown} />
          </div>
          <ul
            tabIndex={-1}
            className="dropdown-content menu bg-base-100 rounded-box z-1 w-52 p-2 shadow-sm"
          >
            <li onClick={() => setFilter("作品")}>
              <a>作品</a>
            </li>
            <li onClick={() => setFilter("作家")}>
              <a>作家</a>
            </li>
            {/* <li onClick={() => setFilter("底本")}>
              <a>底本</a>
            </li> */}
          </ul>
        </div>
        <div className="relative max-w-[75vw]">
          <input
            className="py-1.5 pl-7 pr-1.5 border-gray-300 border-2 rounded-xl w-full"
            type="search"
            value={inputValue}
            onChange={handleChange}
            aria-label="検索"
          />
          <FontAwesomeIcon
            className="text-gray-300 absolute left-1.5 top-3"
            icon={faMagnifyingGlass}
          />
        </div>
        <button
          type="submit"
          className="bg-blue-600 text-white px-5 py-1.5 rounded cursor-pointer"
        >
          検索
        </button>
      </form>
    </>
  );
}
