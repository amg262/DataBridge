import {Sidebar, SidebarState, Image} from '@rewind-ui/core';
import {useState} from "react";
import {
    Book,
    Briefcase, ChartBarIcon, ChevronsLeftRightEllipsis,
    GitBranchIcon, HeartPulse,
    Key,
    LucideRocket, ServerIcon,
    Shield,
    Sliders,
    Users
} from "lucide-react";
import {GitHubLogoIcon} from "@radix-ui/react-icons";
import {Link} from "react-router-dom";

export default function SidebarMenu() {
    const [expanded, setExpanded] = useState(true);
    // const [mobile, setMobile] = useState(false);
    // const sidebar = useSidebar();

    return (
        <>
            <Sidebar color="dark"
                     onToggle={(state: SidebarState) => {
                         setExpanded(state.expanded);
                         // setMobile(state.mobile);
                     }}
                     className="min-h-screen"
            >
                <Sidebar.Head>

                    <Sidebar.Head.Logo>
                        {/*<Image src={"public/ellsworth.jfif"}  width={32} height={32} alt="DataBridge" className="mx-1 rounded-md"/>*/}
                        <Link to="/">
                            <Image src={"/datalake.png"} width={35} height={35} alt="DataBridge"
                                   className="mx-1 rounded-md"/>
                        </Link>
                    </Sidebar.Head.Logo>
                    <Link to="/"
                          className="text-inherit no-underline"
                    >
                        <Sidebar.Head.Title>DataBridge</Sidebar.Head.Title>
                    </Link>
                    <Sidebar.Head.Toggle/>
                </Sidebar.Head>

                <Sidebar.Nav>
                    <Sidebar.Nav.Section>
                        <Sidebar.Nav.Section.Item icon={<LucideRocket/>} label="Dashboard" href="#" active/>
                    </Sidebar.Nav.Section>

                    <Sidebar.Nav.Section>
                        <Sidebar.Nav.Section.Title>Management</Sidebar.Nav.Section.Title>
                        <Sidebar.Nav.Section.Item icon={<Briefcase/>} label="Clients" href="https://localhost:8001/"/>
                        <Sidebar.Nav.Section.Item icon={<Users/>} label="Users" as="button">
                            <Sidebar.Nav.Section isChild>
                                <Sidebar.Nav.Section.Item
                                    icon={<span className="w-1 h-1 rounded bg-transparent"/>}
                                    label="List all"
                                    href="#"
                                />
                                <Sidebar.Nav.Section.Item
                                    icon={<span className="w-1 h-1 rounded bg-transparent"/>}
                                    label="Add new"
                                    href="#"
                                />
                                <Sidebar.Nav.Section.Item
                                    icon={<span className="w-1 h-1 rounded bg-transparent"/>}
                                    label="Archived"
                                    href="#"
                                />
                            </Sidebar.Nav.Section>
                        </Sidebar.Nav.Section.Item>
                        <Sidebar.Nav.Section.Item icon={<Shield/>} label="Roles" href="#"/>
                        <Sidebar.Nav.Section.Item icon={<Key/>} label="Permissions" href="#"/>
                        <Sidebar.Nav.Section.Item icon={<Sliders/>} label="Settings" href="#"/>
                    </Sidebar.Nav.Section>

                    <Sidebar.Nav.Section>
                        <Sidebar.Nav.Section.Title>Support</Sidebar.Nav.Section.Title>
                        <Sidebar.Nav.Section.Item icon={<ChevronsLeftRightEllipsis/>} label="API"
                                                  as={Link} asProps={{
                            to: "https://localhost:8001/swagger/index.html",
                            target: "_blank"
                        }}/>
                        <Sidebar.Nav.Section.Item icon={<ServerIcon/>} label="Hangfire"
                                                  as={Link}
                                                  asProps={{to: "https://localhost:8001/hangfire", target: "_blank"}}/>
                        <Sidebar.Nav.Section.Item icon={<HeartPulse/>} label="Health Checks"
                                                  as={Link}
                                                  asProps={{to: "https://localhost:8001/hc-ui", target: "_blank"}}/>
                        <Sidebar.Separator/>
                        <Sidebar.Nav.Section.Item icon={<Book/>} label="Documentation"
                                                  as={Link}
                                                  asProps={{
                                                      to: "https://dev.azure.com/ea-dxp/DataBridge",
                                                      target: "_blank"
                                                  }}/>
                        <Sidebar.Nav.Section.Item icon={<ChartBarIcon/>} label="Entity Diagram"
                                                  as={Link}
                                                  asProps={{
                                                      to: "public/ERD.png",
                                                      target: "_blank"
                                                  }}/>
                    </Sidebar.Nav.Section>
                </Sidebar.Nav>

                <Sidebar.Footer>
                    <div className="flex flex-col justify-center items-center text-sm my-4">
                        <span className="font-semibold">DataBridge</span>
                        <span>v1.0</span>
                        <div className="flex justify-center items-center mt-2 space-x-2">
                            <Link to="https://www.ellsworth.com" target="_blank" className="text-inherit no-underline">
                                <Image
                                    src="/ellsworth.jfif"
                                    width={32}
                                    height={32}
                                    alt="Ellsworth"
                                    className="rounded-md"
                                />
                            </Link>
                            <Link to="https://dev.azure.com/ea-dxp/DataBridge" className="text-inherit no-underline"
                                  target="_blank">
                                <GitHubLogoIcon width={32} height={32}/>
                            </Link>
                            <Link to="https://dev.azure.com/ea-dxp/DataBridge" className="text-inherit no-underline"
                                  target="_blank">
                                <GitBranchIcon width={32} height={32}/>
                            </Link>
                        </div>
                    </div>
                </Sidebar.Footer>
            </Sidebar>
            <main
                className={`transition-all transform duration-100 text-slate-700 flex w-full flex-col items-center ${
                    expanded ? 'md:ml-64' : 'md:ml-20'
                }`}
            >
            </main>
        </>
    );
}