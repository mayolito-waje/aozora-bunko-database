import React, { useState } from "react";
import { useQuery, useQueryClient } from "@tanstack/react-query";
import axios, { type AxiosResponse } from "axios";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";

import { aozoraApi } from "../../utils/environment-variables";
export default function SearchInput() {
  const [searchQuery, setSearchQuery] = useState<string>("");

  const queryClient = useQueryClient();

  const retrieveWorks = useQuery({
    queryKey: ["fetch-works"],
    queryFn: async () => {
      const response = await axios.get<string, AxiosResponse<[]>>(
        aozoraApi + `writtenWorks/?s=${searchQuery}&pageSize=25`
      );

      return response.data;
    },
  });

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(event.target.value);
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    await queryClient.refetchQueries({ queryKey: ["fetch-works"] });
    console.log(retrieveWorks.data);
  };

  return (
    <>
      <form
        className="flex items-center gap-1.5 mx-auto mt-3 w-fit"
        onSubmit={handleSubmit}
      >
        <div className="relative">
          <input
            className="py-1.5 pl-7 pr-1.5 border-gray-300 border-2 rounded-xl"
            type="search"
            value={searchQuery}
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
