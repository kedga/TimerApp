import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function AddTimerButton() {
    return (
        <div className="h-full w-full flex justify-center items-center">
            <button className="bg-sky-500 hover:bg-sky-400 size-32 aspect-square rounded-full flex justify-center text-white">
                <FontAwesomeIcon
                    className="mx-auto my-auto text-7xl"
                    icon={faPlus}
                />
            </button>
        </div>
    );
}
